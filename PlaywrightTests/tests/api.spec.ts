import { test, expect } from '@playwright/test';
import { lstat } from 'fs';

// Types pentru booking
interface BookingDates {
    checkin: string;
    checkout: string;
}

interface Booking {
    firstname: string;
    lastname: string;
    totalprice: number;
    depositpaid: boolean;
    bookingdates: BookingDates;
    additionalneeds?: string;
}

let authToken: string;
let bookingId: number;

test.describe('Restful-booker API Tests', { tag: ["@regression", "@api"] }, () => {
    test.beforeAll(async ({ request }) => {
        const response = await request.post('https://restful-booker.herokuapp.com/auth', {
            data: {
                username: 'admin',
                password: 'password123'
            }
        });

        expect(response.ok()).toBeTruthy();
        const body = await response.json();
        authToken = body.token;
        console.log('Auth token is:', authToken);
    });

    test('01 - Health Check - ping endpoint', async ({ request }) => {
        const response = await request.get('https://restful-booker.herokuapp.com/ping');

        expect(response.status()).toBe(201);
    });

    test('011 - Get bookings', async ({ request }) => {
        const response = await request.get('https://restful-booker.herokuapp.com/booking');

        expect(response.ok()).toBeTruthy();
        expect(response.status()).toBe(200);

        const bookings = await response.json();

        expect(Array.isArray(bookings)).toBeTruthy();
        expect(bookings.length).toBeGreaterThan(0);
        expect(bookings[0]).toHaveProperty('bookingid');
        console.log(bookings)
    });

    test('012 - Filter booking by name', async ({ request }) => {
        const response = await request.get('https://restful-booker.herokuapp.com/booking',
            {
                params: {
                    firstname: "Mylene",
                    lastname: "Farmer"
                }
            }
        );

        expect(response.ok()).toBeTruthy();
        expect(response.status()).toBe(200);

        const bookings = await response.json();

        expect(Array.isArray(bookings)).toBeTruthy();
        console.log(bookings)
        console.log("Found %s bookings", bookings.length)
    });

    test('013 - Filter booking by checkin/checkout dates', async ({ request }) => {
        const response = await request.get('https://restful-booker.herokuapp.com/booking',
            {
                params: {
                    checkin: "2025-03-10",
                    checkout: "2026-01-11"
                }
            }
        );

        expect(response.ok()).toBeTruthy();
        expect(response.status()).toBe(200);

        const bookings = await response.json();

        expect(Array.isArray(bookings)).toBeTruthy();
        console.log(JSON.stringify(bookings, null, 2))
        console.log("Found %s bookings", bookings.length)
    });

    test('02 - Create a new booking', async ({ request }) => {
        const newBooking: Booking =
        {
            firstname: "Mylene",
            lastname: "Farmer",
            totalprice: 333,
            depositpaid: true,
            bookingdates: {
                checkin: "2026-01-15",
                checkout: "2026-01-20"
            },
            additionalneeds: "Breakfast, Pool"
        }
        console.log('REQUEST PAYLOAD:\n', JSON.stringify(newBooking, null, 2));

        const response = await request.post('https://restful-booker.herokuapp.com/booking',
            { data: newBooking });

        expect(response.ok()).toBeTruthy();
        expect(response.status()).toBe(200);

        const body = await response.json();
        bookingId = body.bookingid;

        console.log('RESPONSE BODY:\n', JSON.stringify(body, null, 2));
        expect(body).toHaveProperty('bookingid');
        expect(body.booking.firstname).toBe(newBooking.firstname);
        expect(body.booking.lastname).toBe(newBooking.lastname);
        expect(body.booking.totalprice).toBe(newBooking.totalprice);

        console.log('Booking created ID:', bookingId);
    });

    test('03 - Booking details by ID', async ({ request }) => {
        const response = await request.get(`https://restful-booker.herokuapp.com/booking/${bookingId}`);

        expect(response.ok()).toBeTruthy();
        expect(response.status()).toBe(200);

        const booking = await response.json();
        console.log('RESPONSE BODY:\n', JSON.stringify(booking, null, 2));
        expect(booking).toHaveProperty('firstname');
        expect(booking).toHaveProperty('lastname');
        expect(booking).toHaveProperty('totalprice');
        expect(booking).toHaveProperty('bookingdates');
        expect(booking.bookingdates).toHaveProperty('checkin');
        expect(booking.bookingdates).toHaveProperty('checkout');
    });

    test('04 - Booking update', async ({ request }) => {
        const partialUpdate = {
            firstname: "Mylene",
            lastname: "Gautier"
        };

        const response = await request.patch(
            `https://restful-booker.herokuapp.com/booking/${bookingId}`,
            {
                headers: {
                    'Cookie': `token=${authToken}`,
                    'Accept': 'application/json'
                },
                data: partialUpdate
            }
        );

        expect(response.ok()).toBeTruthy();
        const body = await response.json();

        console.log('REPSONSE api is: ', JSON.stringify(body, null, 2))

        expect(body.firstname).toBe(partialUpdate.firstname);
        expect(body.lastname).toBe(partialUpdate.lastname);
    });

    test('04 - Booking update checkin time', async ({ request }) => {
        const partialUpdate = {
            bookingdates: {
                checkin: "2026-01-20",
                checkout: "2026-01-25"
            },
        };

        const response = await request.patch(
            `https://restful-booker.herokuapp.com/booking/${bookingId}`,
            {
                headers: {
                    'Cookie': `token=${authToken}`,
                    'Accept': 'application/json'
                },
                data: partialUpdate
            }
        );

        expect(response.ok()).toBeTruthy();
        const body = await response.json();

        console.log('REPSONSE api is: ', JSON.stringify(body, null, 2))

        expect(body.bookingdates.checkin).toBe(partialUpdate.bookingdates.checkin);
        expect(body.bookingdates.checkout).toBe(partialUpdate.bookingdates.checkout);
    });

    test('05 - Delete booking', async ({ request }) => {
        const response = await request.delete(`https://restful-booker.herokuapp.com/booking/${bookingId}`,
            {
                headers: {
                    'Cookie': `token=${authToken}`
                }
            }
        );

        expect(response.status()).toBe(201);
        expect(response.ok()).toBeTruthy();
    });

    test('06 - GET - verify booking was deleted (404 expected)', async ({ request }) => {
        const response = await request.get(
            `https://restful-booker.herokuapp.com/booking/${bookingId}`
        );

        expect(response.status()).toBe(404);
    });

    test('07 - Negative test - create booking with invalid data', async ({ request }) => {
        const invalidBooking = {
            firstname: 'Test',
        };

        const response = await request.post('https://restful-booker.herokuapp.com/booking', {
            data: invalidBooking
        });

        expect(response.status()).toBeGreaterThanOrEqual(400);
    });

    test('08 - Negative test - update without authentication', async ({ request }) => {
        const update = {
            firstname: 'Unauthorized',
            lastname: 'User'
        };

        const response = await request.put(
            'https://restful-booker.herokuapp.com/booking/1',
            {
                data: update
            }
        );

        expect(response.status()).toBe(403);
    });

    test('09 - Negative test - invalid authentication credentials', async ({ request }) => {
        const response = await request.post('https://restful-booker.herokuapp.com/auth', {
            data: {
                username: 'invalid',
                password: 'wrong'
            }
        });

        expect(response.status()).toBe(200);
        const body = await response.json();
        expect(body.reason).toBe('Bad credentials');
    });
})

test.describe('Advanced API Tests', { tag: ["@regression", "@api"] }, () => {

    test('Response time should be acceptable', async ({ request }) => {
        const startTime = Date.now();
        const response = await request.get('https://restful-booker.herokuapp.com/booking');
        const endTime = Date.now();

        const responseTime = endTime - startTime;
        console.log('Response time:', responseTime, 'ms');

        expect(response.ok()).toBeTruthy();
        expect(responseTime).toBeLessThan(3000);
    });

    test('Response headers validation', async ({ request }) => {
        const response = await request.get('https://restful-booker.herokuapp.com/booking');

        const headers = response.headers();
        expect(headers['content-type']).toContain('application/json');
    });

    test('Concurrent requests handling', async ({ request }) => {
        const requests = Array(25).fill(null).map(() =>
            request.get('https://restful-booker.herokuapp.com/booking')
        );

        const startTime = Date.now();
        const responses = await Promise.all(requests);
        const endTime = Date.now();

        const responseTime = endTime - startTime;
        console.log('Response time:', responseTime, 'ms');

        responses.forEach(response => {
            expect(response.ok()).toBeTruthy();
        });
        expect(responseTime).toBeLessThan(3000);
    });

    test('Concurrent requests handling - log response time per request', async ({ request }) => {
        const totalRequests = 25;

        const requests = Array.from({ length: totalRequests }, (_, index) => {
            return (async () => {
                const start = Date.now();

                const response = await request.get(
                    'https://restful-booker.herokuapp.com/booking'
                );

                const end = Date.now();
                const duration = end - start;

                expect(response.ok()).toBeTruthy();

                console.log(`Request ${index + 1} response time: ${duration} ms`);

                return { response, duration };
            })();
        });

        const globalStart = Date.now();
        const results = await Promise.all(requests);
        const globalEnd = Date.now();

        console.log(`\nTotal execution time: ${globalEnd - globalStart} ms for ${totalRequests} requests`);

        results.forEach((r) => {
            expect(r.duration).toBeLessThan(2000);
        });
    });
});