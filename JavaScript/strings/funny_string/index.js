function funny_string(s) {
    let reverse = s.split('').reverse().join('');
    let result = false;
    for (let i = 1; i < s.length; i++) {
        let diff1 = Math.abs(s.charCodeAt(i) - s.charCodeAt(i-1));
        let diff2 = Math.abs(reverse.charCodeAt(i) - reverse.charCodeAt(i-1));
        if(diff1 !== diff2)
        {
            result = false;
            break;
        }
        result = true;
    }
    return result === true ? "Funny" : "Not Funny";
}

module.exports = { funny_string }