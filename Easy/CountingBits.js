/**
 * @param {number} n
 * @return {number[]}
 */
 var countBits = function(n) {
  let ans = [];
  for (let value = 0; value <= n; value++) {
      let flag = 1;
      let count = 0;
      while (flag <= value) {
          if ((flag & value) !== 0) count++;
          flag = flag << 1; // shift flag left one bit
      }
      ans.push(count);
  }
      
  return ans;
};

/* 

  Explanation:
  
  Brute force solution: loop from 0 to n and use bit manipulation to count the number of 1s in the binary representation of each value.
  
  Time complexity: O(nlog(n)) multiply by log(n) since we're checking each bit by doubling starting from 1 (flag)
  Space complexity: O(n)
  where n is the range of values from 0 to n

*/



/**
 * @param {number} n
 * @return {number[]}
 */
 var countBits = function(n) {
  let ans = [ 0 ];
  
  let map = { 0: 0 };
  let offset = 1;
  
  for (let value = 1; value <= n; value++) {
      if (value === offset*2) offset *= 2;
      map[value] = 1 + map[value - offset];
      ans.push(map[value]);
  }
  
  return ans;
};

/* 

  Explanation:
  
  Bottom-up DP solution: 
  // 000    = -------------- = 0    map = [ 0: 0 ]
  // 001    = 1 + map(1 - 1) = 1    map = [ 0: 0, 1: 1 ]
  // 010    = 1 + map(2 - 2) = 1    map = [ 0: 0, 1: 1, 2: 1 ]
  // 011    = 1 + map(3 - 2) = 2    map = [ 0: 0, 1: 1, 2: 1, 3: 2 ]
  // 100    = 1 + map(4 - 4) = 1    map = [ 0: 0, 1: 1, 2: 1, 3: 2, 4: 1 ]
  // 101    = 1 + map(5 - 4) = 2    map = [ 0: 0, 1: 1, 2: 1, 3: 2, 4: 1, 5: 2 ]
  // 110    = 1 + map(6 - 4) = 2    map = [ 0: 0, 1: 1, 2: 1, 3: 2, 4: 1, 5: 2, 6: 2 ]
  // 111    = 1 + map(7 - 4) = 3    map = [ 0: 0, 1: 1, 2: 1, 3: 2, 4: 1, 5: 2, 6: 2, 7: 3 ]

  Time Complexity: 0(n)
  Space Complexity: O(n)

  where n is the range from 0 to n

*/
