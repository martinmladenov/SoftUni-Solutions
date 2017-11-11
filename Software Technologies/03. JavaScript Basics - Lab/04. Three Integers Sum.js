function solve([nums]) {
    nums = nums.split(' ').map(Number);
    if (nums[0] + nums[1] === nums[2])
        return `${Math.min(nums[0], nums[1])} + ${Math.max(nums[0], nums[1])} = ${nums[2]}`;
    if (nums[2] + nums[1] === nums[0])
        return `${Math.min(nums[2], nums[1])} + ${Math.max(nums[2], nums[1])} = ${nums[0]}`;
    if (nums[0] + nums[2] === nums[1])
        return `${Math.min(nums[0], nums[2])} + ${Math.max(nums[0], nums[2])} = ${nums[1]}`;
    return 'No';
}