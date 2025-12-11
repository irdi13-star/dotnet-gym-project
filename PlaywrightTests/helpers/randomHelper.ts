export const randomInt = (min = 1, max = 10) =>
    Math.floor(Math.random() * (max - min + 1)) + min;

export const randomNumber = (length: number) => {
    let result = "";
    const characters = "1234567890";
    for (let i = 0; i < length; i += 1) {
        result += characters.charAt(Math.floor(Math.random() * characters.length));
    }
    return result;
};
