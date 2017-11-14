function solve(arr) {
    let obj = {};
    for (let line of arr) {
        let spl = line.split(' -> ');
        if (!isNaN(Number(spl[1])))
            spl[1] = Number(spl[1]);
        obj[spl[0]] = spl[1];
    }
    return JSON.stringify(obj);
}