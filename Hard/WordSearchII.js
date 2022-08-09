/**
 * @param {character[][]} board
 * @param {string[]} words
 * @return {string[]}
 */
var findWords = function(board, words) {
  
  let trie = new Trie();
  for (let word of words)
    trie.addWord(word);

  let nRows = board.length;
  let nCols = board[0].length;
  
  let res = new Set();
  let visited = new Set();
  
  let dfs = function(r, c, node, word) {
    
    let key = [r,c].toString();
    if (r < 0 || r === nRows || c < 0 || c === nCols || visited.has(key))
      return;
    
    let ch = board[r][c];
    if (!node.children[ch])
      return;
    
    visited.add(key);
    node = node.children[ch];
    word += ch;
    if (node.word)
      res.add(word);
    
    dfs(r + 1, c, node, word);
    dfs(r - 1, c, node, word);
    dfs(r, c + 1, node, word);
    dfs(r, c - 1, node, word);
    visited.delete(key);
  }
  
  for (let r = 0; r < nRows; r++) {
    for (let c = 0; c < nCols; c++) {
      dfs(r, c, trie.root, "");
    }
  }
  
  return [...res];
};

class TrieNode {
  constructor() {
    this.children = {};
    this.word = false;
  }
}

class Trie {
  constructor() {
    this.root = new TrieNode();
  }
  
  addWord(word) {
    let current = this.root;
    for (let c of word) {
      if (!current.children[c])
        current.children[c] = new TrieNode();
      current = current.children[c];
    }
    current.word = true;
  }
}

/*

    Time: O(W + (r*c)*3^w)

    W = # of words
    w = average word length

*/

