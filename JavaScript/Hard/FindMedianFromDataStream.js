var MedianFinder = function() {
  this.largeHeap = new MinHeap();
  this.smallHeap = new MaxHeap();
};

/** 
 * @param {number} num
 * @return {void}
 */
MedianFinder.prototype.addNum = function(num) {
  // default to adding to small heap
  this.smallHeap.insert(num);
  
  // make sure every element in small heap is <= to every element in large heap
  if (this.smallHeap.heap[0] > this.largeHeap.heap[0]) {
    let val = this.smallHeap.popMax();
    this.largeHeap.insert(val);
  }
  
  // check for uneven sizes
  if (this.smallHeap.heap.length > this.largeHeap.heap.length + 1) {
    let val = this.smallHeap.popMax();
    this.largeHeap.insert(val);
  }
  
  // check for uneven sizes
  if (this.largeHeap.heap.length > this.smallHeap.heap.length + 1) {
    let val = this.largeHeap.popMin();
    this.smallHeap.insert(val);
  }
};

/**
 * @return {number}
 */
MedianFinder.prototype.findMedian = function() {
  if (this.smallHeap.heap.length > this.largeHeap.heap.length)
    return this.smallHeap.heap[0];
  if (this.largeHeap.heap.length > this.smallHeap.heap.length)
    return this.largeHeap.heap[0];

  return (this.smallHeap.heap[0] + this.largeHeap.heap[0]) / 2; 
};

/** 
 * Your MedianFinder object will be instantiated and called as such:
 * var obj = new MedianFinder()
 * obj.addNum(num)
 * var param_2 = obj.findMedian()
 */

/*

  Time: O(logn) - addNum
  Time: O(1)    - findMedian
  Space: O(n)
  
  Explanation - use two heaps:
  * A small heap that holds the smaller half of the numbers
  * A large heap that holds the larger half of the numbers
  * The small heap is a max heap for quick access to the largest number in the smaller half
  * The large heap is a min heap for quick access to the smallest number in the larger half
  * Keep the size of both heaps the same

  Example:
  nums = [1,2,3,4]
  smallHeap = [2,1]
  largeHeap = [3.4]
  
*/

class MaxHeap {
    
  constructor() {
    this.heap = [];
  }

  insert(value) {
    this.heap.push(value);
    let i = this.heap.length - 1;
    this.bubbleUp(i);
  }

  swap(a, b) {
    let temp = this.heap[a];
    this.heap[a] = this.heap[b];
    this.heap[b] = temp;
  }

  bubbleUp(index) {
    while (this.heap[this.parent(index)] !== undefined && this.heap[this.parent(index)] < this.heap[index]) {
      this.swap(this.parent(index), index);
      index = this.parent(index);
    }
  }

  heapify(index) {
    while (true) {
      let left = this.left(index),
        right = this.right(index);

      if (this.heap[left] !== undefined && this.heap[right] !== undefined && this.heap[left] > this.heap[right] && this.heap[index] < this.heap[left]) {
        this.swap(left, index);
        index = left;
      } else if (this.heap[left] !== undefined && this.heap[right] !== undefined && this.heap[right] > this.heap[left] && this.heap[index] < this.heap[right]) {
        this.swap(right, index);
        index = right;
      } else if (this.heap[left] !== undefined && this.heap[index] < this.heap[left]) {
        this.swap(left, index);
        index = left;
      } else if (this.heap[right] !== undefined && this.heap[index] < this.heap[right]){
        this.swap(right, index);
        index = right;
      } else {
        break;
      }
    }
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

class MinHeap {
    
  constructor() {
    this.heap = [];
  }

  insert(value) {
    this.heap.push(value);
    let i = this.heap.length - 1;
    this.bubbleUp(i);
  }

  swap(a, b) {
    let temp = this.heap[a];
    this.heap[a] = this.heap[b];
    this.heap[b] = temp;
  }

  bubbleUp(index) {
    while (this.heap[this.parent(index)] !== undefined && this.heap[this.parent(index)] > this.heap[index]) {
      this.swap(this.parent(index), index);
      index = this.parent(index);
    }
  }

  heapify(index) {
    while (true) {
      let left = this.left(index),
        right = this.right(index);

      if (this.heap[left] !== undefined && this.heap[right] !== undefined && this.heap[left] < this.heap[right] && this.heap[index] > this.heap[left]) {
        this.swap(left, index);
        index = left;
      } else if (this.heap[left] !== undefined && this.heap[right] !== undefined && this.heap[right] < this.heap[left] && this.heap[index] > this.heap[right]) {
        this.swap(right, index);
        index = right;
      } else if (this.heap[left] !== undefined && this.heap[index] > this.heap[left]) {
        this.swap(left, index);
        index = left;
      } else if (this.heap[right] !== undefined && this.heap[index] > this.heap[right]){
        this.swap(right, index);
        index = right;
      } else {
        break;
      }
    }
  }

  popMin() {
    this.swap(0, this.heap.length - 1);
    let min = this.heap.pop();
    this.heapify(0);
    return min;
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
