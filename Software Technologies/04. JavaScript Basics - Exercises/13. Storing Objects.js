function solve(arr) {
    let dict = [];
    for(let line of arr){
        let spl = line.split(' -> ');
        dict.push({Name: spl[0], Age: spl[1], Grade: spl[2]});
    }
    for(let obj of dict){
        console.log(`Name: ${obj.Name}`);
        console.log(`Age: ${obj.Age}`);
        console.log(`Grade: ${obj.Grade}`);
    }
}