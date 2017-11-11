function solve(input) {
    input = input.join(' ');
    let rgx = /\b[A-Z]+\b/g;
    let matches = [];
    let  i = 0;
    while (true) {
        let match = rgx.exec(input);
        if (match === null || i > 40)
            break;
        matches.push(match);
        i++;
    }
    console.log(matches.join(', '));
}