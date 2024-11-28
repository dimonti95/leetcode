/**
 * @param {number[]} numbers
 * @param {number} target
 * @return {number[]}
 */
 var twoSum = function(numbers, target) {
    
  let i = 0;
  let j = numbers.length - 1;
  
  let sum = numbers[i] + numbers[j];
  
  while (i < j) {
      
      if (sum === target) return [ i + 1, j + 1 ];
      
      if (sum < target) i++;
      if (sum > target) j--;
      
      sum = numbers[i] + numbers[j];
      
  }
  
};

/*

  Using two pointers check the sum each iteration and if the current sum is greater than target go to the next 
  smallest number from j, if the current sum is smaller than the target go to the next largest number from i.

  Time Complexity: O(n)
  Space Complexity: O(1)
  
  Where n is the length of numbers.

*/



/**
 * @param {number[]} numbers
 * @param {number} target
 * @return {number[]}
 */
 var twoSum = function(numbers, target) {
    
  let map = {};
  
  for (let i = 0; i < numbers.length; i++) {
      map[numbers[i]] = i;
  }
  
  for (let i = 0; i < numbers.length; i++) {
      let current = target - numbers[i];
      if (map[current]) return [ i + 1, map[current] + 1 ];
  }
  
};

/*

  Create a map that maps each value in numbers to its index then loop over numbers and check if the difference (target - current) exists is the map.
  Then return the indecies where those values are found.

  Time Complexity: O(n)
  Space Complexity: O(n)
  
  Where n is the length of numbers.

*/
