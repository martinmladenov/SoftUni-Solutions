function solve(nums) {
    for (let i of nums.map(Number).sort((a, b) => b - a).slice(0, 3)) {
        console.log(i);
    }
}