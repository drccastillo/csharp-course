# Data Structures – Concept & Implementation

## Overview

This project provides both **theoretical foundations** and a **hands-on implementation** of essential data structures using advanced **object-oriented programming (OOP)** principles and **clean architecture**.

It includes:

- A clear explanation of **what data structures are** and **why they matter**.
- Custom implementations of core **linear data structures**.
- Practical tasks and testing strategies to strengthen your understanding.

---

## 📚 What is a Data Structure?

A **data structure** is a specialized format for organizing, processing, retrieving, and storing data. It defines the relationship between data elements and the operations that can be performed on them.

### Why Are Data Structures Important?

- ✅ Efficient data management  
- 📦 Logical data organization  
- 🔍 Abstraction from implementation details  
- 🔁 Reusability across applications  
- ⚡ Performance improvements in algorithms  

---

## 📊 Classification of Data Structures

### Linear Data Structures

Data is stored sequentially:

- **Array** – Fixed-size structure, fast access via index.
- **Linked List** – Dynamically growing, flexible insert/delete.
- **Queue** – FIFO structure for fair processing.
- **Stack** – LIFO structure for nested or undo operations.

### Non-Linear Data Structures

Data is stored in hierarchical or interconnected formats:

- **Tree** – Hierarchical data model.
- **Graph** – Network-like relationships.
- **Hash Table** – Fast key-based lookup via hashing.

---

## 🔧 Custom Implementations

This project includes custom generic implementations of the following linear structures:

| Structure              | Description                                                                                       |
|------------------------|---------------------------------------------------------------------------------------------------|
| `DynamicArray<T>`      | Resizable array with dynamic capacity and full CRUD operations, including enumerator support.     |
| `CustomStack<T>`       | LIFO stack using singly linked list with `Push`, `Pop`, `Peek`, and conversion to array.          |
| `CustomQueue<T>`       | Circular-buffer-based FIFO queue supporting `Enqueue`, `Dequeue`, and `Peek`.                     |
| `CustomLinkedList<T>`  | Singly linked list with flexible node operations (`AddFirst`, `AddLast`, `TryRemove`, etc.).      |
| `DoublyLinkedList<T>`  | Bidirectional linked list supporting reverse traversal and optimized insert/remove.               |

📌 *Each structure includes essential methods and is fully type-generic (`<T>`).*

---

## ✅ Task Classification

| File                      | Task Comment                            | Classification |
|---------------------------|------------------------------------------|----------------|
| `CustomQueue.cs`          | `// TODO: Implement queue`               | Required       |
| `CustomStack.cs`          | `// TODO: Convertir a array`             | Required       |
| `TestCustomStack.cs`      | `// TODO: Complete test` (2 places)      | Required       |
| `TestCustomQueue.cs`      | `// TODO: All tests should pass`         | Required       |
| `CustomLinkedList.cs`     | `// OPTIONAL: Enhance`                   | Optional       |
| `DynamicArray.cs`         | `// OPTIONAL: Enhance the logic`         | Optional       |
| `TestDoublyLinkedList.cs` | `// OPTIONAL: Add more tests if wanted`  | Optional       |

---

## 🧠 Design Decisions

- **Circular Buffer**: Improves efficiency in `CustomQueue<T>` by avoiding data shifts.
- **Linked List-Based Stack/Queue**: Enables constant-time insertions/removals in `CustomStack<T>` and `CustomLinkedList<T>`.
- **Dynamic Capacity**: `DynamicArray<T>` doubles size to balance performance and memory usage.
- **Bidirectional Navigation**: `DoublyLinkedList<T>` supports efficient forward and backward traversal.

---

## 🧪 Testing

- Test files follow the [xUnit](https://xunit.net/) pattern.
- Ensure 100% test coverage for required files.
- Optional enhancements can be tested incrementally.

---

## 📐 UML Class Diagram

For a visual representation of the class relationships, refer to:

```
uml/diagram.mmd
```

(Uses [Mermaid syntax](https://mermaid.js.org/) for easy visualization.)

---

## 🖼️ Illustration

![List](./lists.png)
