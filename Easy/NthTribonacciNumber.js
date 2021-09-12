/**
 * @param {number} n
 * @return {number}
 */
 var tribonacci = function(n) {
  let t1 = 0;
  let t2 = 1;
  let t3 = 1;
  while (n > 0) {
      const temp = t3;
      t3 = t1 + t2 + t3;
      t1 = t2;
      t2 = temp;
      n--;
  }
  return t1;
};

/*

  Iterative

*/



/**
 * @param {number} n
 * @return {number}
 */
 var tribonacci = function(n) {
  
  let mem = {};
  
  let trib = function(t) {
      if (t < 3) return t === 0 ? 0 : 1;
      if (mem[t]) return mem[t];
      mem[t] = trib(t-1) + trib(t-2) + trib(t-3);
      return mem[t];
  }
  
  return trib(n);

};

/*

  Recursive

*/
