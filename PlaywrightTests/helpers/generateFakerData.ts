import { fakerEN_GB as faker } from "@faker-js/faker";

import { randomNumber } from "./randomHelper";

const validDate = faker.date.between({
  from: "1980-01-01T00:00:00.000Z",
  to: "2000-01-01T00:00:00.000Z",
});

export default class FakeDataProvider {
  public getFirstName() {
    return faker.person.firstName();
  }

  public getLastName() {
    return faker.person.lastName();
  }

  public getUsername() {
    return faker.word.noun({ length: { min: 8, max: 12 }, strategy: "fail" });
  }

  public getPhoneNumber() {
    return `07${randomNumber(9)}`;
  }

  public getEmail() {
    return `luts.sharlota+${randomNumber(10)}@gmail.com`;
  }

  public getDobDate() {
    return validDate.getDate().toString();
  }

  public getDobMonth() {
    return (validDate.getMonth() + 1).toString();
  }

  public getDobYear() {
    return validDate.getFullYear().toString();
  }
}
