function solve(arr) {
    if (arr.filter(n => n[0] === '-').length % 2 === 0)
        return 'Positive';
    return 'Negative';
}