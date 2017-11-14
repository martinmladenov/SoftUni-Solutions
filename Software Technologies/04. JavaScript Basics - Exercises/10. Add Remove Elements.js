function solve(input) {
    let arr = [];
    for (let i = 0; i < input.length; i++) {
        let spl = input[i].split(' ');
        if (spl[0] === 'add')
            arr.push(Number(spl[1]));
        else if (spl[0] === 'remove')
            arr.splice(Number(spl[1]), 1);
    }
    for (let i = 0; i < arr.length; i++)
        console.log(i in arr ? arr[i] : 0);
}