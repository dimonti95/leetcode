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
    
    let heap = new MaxHeap(k);
    
    let seen = {};
    for (let num of nums) {
        if (!seen[num]) heap.insert([num, count[num]]); // [key, frequency]
        seen[num] = true;
    }

    let ans = [];
    while (k > 0) {
        let current = heap.popMax();
        ans.push(current[0]);
        k--;
    }
    
    return ans;
};



class MaxHeap {
    
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
    
    Time: O(nlogk)
    Space: O(n + k)

    Where n is the number of elements in the list and k is the number of most frequent elements beign returned

*/
