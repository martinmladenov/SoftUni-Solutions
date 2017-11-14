function solve(arr) {
    arr = arr.map(Number);
    let n = arr[0];
    let x = arr[1];
    if(x>=n)
        return n*x;
    return n/x;
}