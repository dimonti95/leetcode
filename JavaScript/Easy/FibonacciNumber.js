/**
 * @param {number} n
 * @return {number}
 */
 var fib = function(n) {
    if (map[n]) return map[n];
    if (n <= 2) return n === 0 ? 0 : 1;
     
    map[n] = fib(n-1) + fib(n-2)
    return map[n]
 };

 let map = {};
 
 /* 
 
     Explanation:
     
     Memoized recursive solution

     Time Complexity: O(n)
     Space Complexity: O(n)

     where n is the number in the sequence we're looking for
 
 */
 

  
/**
 * @param {number} n
 * @return {number}
 */
var fib = function(n) {
  
    if (n === 0) return 0;
    
    let f1 = 0;
    let f2 = 1;
    let count = 1;
    
    while (count < n) {
        let temp = f2;
        f2 = f1 + f2;
        f1 = temp;
        count++;
    }
    
    return f2;
};
  
/* 

    Explanation:
    
    Iterative bottoms up solution.
    
    Time Complexity: O(n)
    Space Complexity: O(1)
    
    where n is the number in the fib sequence we're looking for

*/
