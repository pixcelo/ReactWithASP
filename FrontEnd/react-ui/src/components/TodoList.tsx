import React from 'react';
import { Todo } from '../types';

interface TodoListProps {
  todos: Todo[];
  isLoading: boolean;
}

const TodoList: React.FC<TodoListProps> = ({ todos, isLoading }) => {
  return (
    <div>
      <h2>Todo List</h2>
      {isLoading ? (
        <p>Loading...</p>
      ) : (
        <ul>
          {todos.map((todo) => (
            <li key={todo.id}>
              <h3>Title: {todo.title}</h3>
              <p>Description: {todo.description}</p>
              <p>Due Date: {todo.dueDate}</p>
              <p>Completed: {todo.isCompleted ? 'Yes' : 'No'}</p>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default TodoList;