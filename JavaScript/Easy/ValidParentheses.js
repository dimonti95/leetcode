/**
 * @param {string} s
 * @return {boolean}
 */
 var isValid = function(s) {
    
    let stack = [];

	for (let i = 0; i < s.length; i++) {
		if (s.charAt(i) === '(' || s.charAt(i) === '{' || s.charAt(i) === '[') stack.push(s.charAt(i));
		else {
			const lastOpen = stack.pop();
			if (s.charAt(i) === ')' && lastOpen !== '(') return false;
			if (s.charAt(i) === '}' && lastOpen !== '{') return false;
			if (s.charAt(i) === ']' && lastOpen !== '[') return false;
		}
	}
    
    if (stack.length > 0) return false;

	return true;
    
};

/*
    
    Time Complexity: O(n)
    Space Complexity: O(n)
    
    Where n is the length of the string

*/
