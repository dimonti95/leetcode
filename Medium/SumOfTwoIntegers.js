/**
 * @param {number} a
 * @param {number} b
 * @return {number}
 */
 var getSum = function(a, b) {
  
    while (b !== 0) {
		let temp = a;
		a = a ^ b;
		b = (temp & b) << 1;
	}
    
	return a;  
};

/*

    Example:
    a = 1010
    b = 0011
    
    1st iteration:
    temp = 1010
    a = 1001
    b = 0100
    
    2nd iteration:
    temp = 1001
    a = 1101
    b = 0000
    
    answer = 1101 = 13
    
    Time Complexity: O(1)
    Space Complexty: O(1)

*/
