function solve(input) {
    let arr = [];
    for (let i = 0; i < input.length - 1; i++) {
        let spl = input[i].split(' ');
        arr[spl[0]] = spl[1];
    }
    let key = input[input.length - 1];
    if (key in arr)
        return arr[key];
    return "None";
}