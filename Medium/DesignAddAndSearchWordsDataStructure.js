class DictionaryNode {
    constructor(letter) {
        this.children = {};
        this.word = false;
    }
}

var WordDictionary = function() {
    this.root = new DictionaryNode(null);
};

/** 
 * @param {string} word
 * @return {void}
 */
WordDictionary.prototype.addWord = function(word) {
    let current = this.root;
    for (let letter of word) {
        if (!current.children[letter]) {
            current.children[letter] = new DictionaryNode();
        }
        current = current.children[letter];
    }
    current.word = true;
};

/** 
 * @param {string} word
 * @return {boolean}
 */
WordDictionary.prototype.search = function(word) {
    
    let dfs = function (j, node) {
        for (let i = j; i < word.length; i++) {
            let letter = word.charAt(i);
        
            if (!node.children[letter]) {
                if (letter === '.') {
                    for (let child in node.children) {
                        if (dfs(i + 1, node.children[child])) return true;
                    }
                }
                
                return false;
            }
            else {
                node = node.children[letter];
            }
        }
        return node.word;
    }
    
    return dfs(0, this.root);
};

/** 
 * Your WordDictionary object will be instantiated and called as such:
 * var obj = new WordDictionary()
 * obj.addWord(word)
 * var param_2 = obj.search(word)
 */

/*

    Add Word
    Time: O(w)
    Space: O(w)

    Where w is the length of the word


    Search Word
    Time: O(w * 26^w)
    Space: O(1) to search word without dots
           O(w) to search words with dots to keep the recursion stack

    Where w is the length of the word

*/



class TrieNode {
  constructor() {
    this.children = {};
    this.word = false;
  }
}

var WordDictionary = function() {
   this.root = new TrieNode(); 
};

/** 
 * @param {string} word
 * @return {void}
 */
WordDictionary.prototype.addWord = function(word) {
  let current = this.root;
  for (let i = 0; i < word.length; i++) {
    let c = word.charAt(i);
    if (!current.children[c])
      current.children[c] = new TrieNode();
    current = current.children[c];
  }
  current.word = true;
};

/** 
 * @param {string} word
 * @return {boolean}
 */
WordDictionary.prototype.search = function(word) {
  
  let dfs = function(current, index) {
    if (index === word.length)
      return current.word;
    
    let c = word.charAt(index);
    
    if (c === '.') {
      for (let key in current.children) {
        if (dfs(current.children[key], index + 1))
          return true;
      }
      return false;
    }
    else {
      if (!current.children[c])
        return false;
      return dfs(current.children[c], index + 1);
    }
  }
  
  return dfs(this.root, 0);
};

/** 
 * Your WordDictionary object will be instantiated and called as such:
 * var obj = new WordDictionary()
 * obj.addWord(word)
 * var param_2 = obj.search(word)
 */

/*
    Another way to implement DFS without the inner loop.

    Add Word
    Time: O(w)
    Space: O(w)

    Search Word
    Time: O(w * 26^w)
    Space: O(w) to search words with dots to keep the recursion stack

    Where w is the length of the word

*/
