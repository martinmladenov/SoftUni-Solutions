function solve(input) {
    input = input.map(JSON.parse);
    let income = {};
    for (let town of input) {
        if (town.town in income)
            income[town.town] += Number(town.income);
        else
            income[town.town] = Number(town.income);
    }
    for (let town of Object.keys(income).sort())
        console.log(`${town} -> ${income[town]}`)
}