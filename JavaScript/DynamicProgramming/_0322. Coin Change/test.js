const {coinChange} = require('./index')

test("Input: coins = [1,2,5], amount = 11", () => {
    expect(coinChange([1, 2, 5], 11)).toBe(3);
});
//
// test("Input: coins = [2], amount = 3", () => {
//     expect(coinChange([2], 3)).toBe(-1);
// });
//
// test("Input: coins = [1], amount = 0", () => {
//     expect(coinChange([1], 0)).toBe(0);
// });
//
// test("Input: coins = [1], amount = 1", () => {
//     expect(coinChange([1], 1)).toBe(1);
// });
//
// test("Input: coins = [1], amount = 2", () => {
//     expect(coinChange([1], 2)).toBe(2);
// });

// test("Input: coins = [58,92,387,421,194,208,231], amount = 7798", () => {
//     expect(coinChange([58,92,387,421,194,208,231], 7798)).toBe(21);
// });


