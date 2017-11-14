function solve(input) {
    let arr = [];
    for (let i = 0; i < input.length - 1; i++) {
        let spl = input[i].split(' ');
        if (!(spl[0] in arr))
            arr[spl[0]] = [];
        arr[spl[0]].push(spl[1]);
    }
    let key = input[input.length - 1];
    if (key in arr)
        return arr[key].join('\n');
    return "None";
}