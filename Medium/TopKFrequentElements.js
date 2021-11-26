/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number[]}
 */
 var topKFrequent = function(nums, k) {
    
    // if k is the size of the array all numbers are unique
    if (k === nums.length) return nums;
  
    let count = {};
    for (let num of nums) {
        if (count[num] === undefined) count[num] = 0;
        count[num] += 1;
    }
    
    let heap = new MinHeap(k);
    
    let seen = {};
    for (let num of nums) {
        if (!seen[num]) heap.insert([num, count[num]]); // [key, frequency]
        seen[num] = true;

        // only keep the k largest (most frequent) elements so that each insert runs in O(logk) rather than O(logn)
        if (heap.heap.length > k) heap.popMin();
    }

    let ans = [];
    while (k > 0) {
        let current = heap.popMin();
        ans.push(current[0]);
        k--;
    }
    
    return ans;
};

class MinHeap {
    
    constructor(size) {
        this.size = size || 0;
        this.heap = [];
    }

    insert(value) {
        this.heap.push(value);

        let currentIndex = this.heap.length - 1;
        this.bubbleUp(currentIndex);
    }

    swap(a, b) {
        let temp = this.heap[a];
        this.heap[a] = this.heap[b];
        this.heap[b] = temp;
    }

    bubbleUp(index) {
        while (this.heap[this.parent(index)] && this.heap[this.parent(index)][1] > this.heap[index][1]) {
            this.swap(this.parent(index), index);
            index = this.parent(index);
        }
    }

    heapify(index) {
        while (true) {
            let left = this.left(index),
                right = this.right(index);

            if (this.heap[left] && this.heap[right] && this.heap[left][1] < this.heap[right][1] && this.heap[index][1] > this.heap[left][1]) {
                this.swap(left, index);
                index = left;
            } else if (this.heap[left] && this.heap[right] && this.heap[right][1] < this.heap[left][1] && this.heap[index][1] > this.heap[right][1]) {
                this.swap(right, index);
                index = right;
            } else if (this.heap[left] && this.heap[index][1] > this.heap[left][1]) {
                this.swap(left, index);
                index = left;
            } else if (this.heap[right] && this.heap[index][1] > this.heap[right][1]){
                this.swap(right, index);
                index = right;
            } else {
                break;
            }
        }
    }

    popMin() {
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

    Use a min heap to easily remove the least frequent elements. Keep only the k most frequent elements in the min heap
    for O(logk) remove/insert operations rather than O(logn) remove/insert operations
    
    Time: O(nlogk)
    Space: O(n + k)

    Where n is the number of elements in the list and k is the number of most frequent elements beign returned


    ------------------------------------------------------------------------------------------------

    Why build a heap containing only the k most frequent elements?
    
    (1) The heap is initialized to a size of k
    (2) Start adding each unique element to the heap
    (3) Once the heaps size is larger than k remove the smallest (least frequent) element, since
    it's garenteed that those elements won't be one of the k most frequent

*/
