let findNumbers = function (nums) {
    let count = 0;
    for (let num of nums) {
        if (num.toString().split('').length % 2 === 0)
            count++;
    }
    return count;
};

module.exports = {findNumbers};
