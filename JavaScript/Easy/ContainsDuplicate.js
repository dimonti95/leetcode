/**
 * @param {number[]} nums
 * @return {boolean}
 */
 var containsDuplicate = function(nums) {
  let set = new Set();

  for (let num of nums) {
    if (set.has(num)) return true;
    set.add(num);
  }

  return false;
};

/*

  Keep a set of unique numbers and return false on duplicates
  
  Time Complexity: O(n)
  Space Complexity: O(n)

  Where n is the size of the array    

*/
