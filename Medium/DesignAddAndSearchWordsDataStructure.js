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
