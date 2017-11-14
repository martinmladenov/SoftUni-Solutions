function solve(arr) {
    let dict = [];
    for (let line of arr) {
        dict.push(JSON.parse(line));
    }
    for (let obj of dict) {
        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Date: ${obj.date}`);
    }
}