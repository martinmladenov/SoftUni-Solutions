function solve([n]) {
    n = Number(n);
    for (let i = 1; i <= n; i++) {
        if (isSymmetric(i))
            console.log(i + " ");
    }

    function isSymmetric(n) {
        n = n.toString();
        for (let i = 0; i < n.length / 2; i++)
            if (n[i] !== n[n.length - 1 - i]) return false;
        return true;
    }
}