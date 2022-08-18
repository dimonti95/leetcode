/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number[]}
 */
var topKFrequent = function(nums, k) {
  
  let count = {};
  for (let num of nums) {
    if (count[num] === undefined)
      count[num] = 0;
    count[num] += 1;
  }

  let bucket = [];
  for (let key in count) {
    if (bucket[count[key]] === undefined)
      bucket[count[key]] = [];
    bucket[count[key]].push(key);
  }
  
  let res = [];
  for (let i = bucket.length - 1; i >= 0; i--) {
    if (bucket[i]) {
      for (let num of bucket[i]) {
        res.push(num);
        k--;
        if (k === 0)
          return res;
      }
    }
  }
  
};

/* 

  Bucket sort

  Time: O(n)
  Space: O(n)

*/



/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number[]}
 */
 var topKFrequent = function(nums, k) {
  
  let counts = {};
  for (let num of nums) {
    if (counts[num] === undefined)
      counts[num] = 0;
    counts[num] += 1;
  }
  
  // O(n) - worst case each element is unique
  let heap = new MaxHeap();
  for (let key in counts)
    heap.insert([key, counts[key]]); // [key, frequency]
  
  // O(n) - worst case each element is unique
  heap.buildHeap();
  
  // O(klogn)
  let res = [];
  while (k > 0) {
    let nextMax = heap.popMax();
    res.push(nextMax[0]);
    k -= 1;
  }
    
  return res;
};
  
class MaxHeap {
    
  constructor() {
    this.heap = [];
  }

  insert(value) {
    this.heap.push(value);
  }

  swap(a, b) {
    let temp = this.heap[a];
    this.heap[a] = this.heap[b];
    this.heap[b] = temp;
  }

  bubbleUp(index) {
    while (this.heap[this.parent(index)] && this.heap[this.parent(index)][1] < this.heap[index][1]) {
      this.swap(this.parent(index), index);
      index = this.parent(index);
    }
  }

  heapify(index) {
    while (true) {
      let left = this.left(index),
        right = this.right(index);

      if (this.heap[left] && this.heap[right] && this.heap[left][1] > this.heap[right][1] && this.heap[index][1] < this.heap[left][1]) {
        this.swap(left, index);
        index = left;
      } else if (this.heap[left] && this.heap[right] && this.heap[right][1] > this.heap[left][1] && this.heap[index][1] < this.heap[right][1]) {
        this.swap(right, index);
        index = right;
      } else if (this.heap[left] && this.heap[index][1] < this.heap[left][1]) {
        this.swap(left, index);
        index = left;
      } else if (this.heap[right] && this.heap[index][1] < this.heap[right][1]){
        this.swap(right, index);
        index = right;
      } else {
        break;
      }
    }
  }

  buildHeap() {
    let startIndex = Math.floor(this.heap.length / 2 - 1);
    for (let i = startIndex; i >= 0; i--)
      this.heapify(i);
  }

  popMax() {
    this.swap(0, this.heap.length - 1);
    let max = this.heap.pop();
    this.heapify(0);
    return max;
  }

  parent(index) {
    return Math.floor((index - 1) / 2);
  }

  left(index) {
    return 2 * index + 1;
  }

  right(index) {
    return 2 * index + 2;
  }
}
  
  /*

    Time: O(klogn)
    Space: O(n)
  
  */
