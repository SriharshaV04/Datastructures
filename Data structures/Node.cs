using System;

class Node {
    public int value;
    public int pointer;

    public Node(int value, int pointer = -1) {
        this.value = value;
        this.pointer = pointer;
    }
}