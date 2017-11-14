function solve(input) {
    let n = Number(input[0]);
    let arr = new Array(n);
    for (let i = 1; i < input.length; i++) {
        let spl = input[i].split(' - ').map(Number);
        arr[spl[0]] = spl[1];
    }
    for (let i = 0; i < n; i++)
        console.log(i in arr ? arr[i] : 0);
}