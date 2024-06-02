import { useEffect, useState } from 'react'
import './App.css'

interface ApiData {
  date: string,
  temperatureC: string,
  temperatureF: number,
  summary: string
}

interface Todo {
  id: number,
  title: string | null,
  description: string | null,
  priority: number | null,
  dueDate: string | null,
  createdAt: string,
  completedAt: string | null,
  isCompleted: number | null,
  projectId: number| null
}

function App() {
  const [count, setCount] = useState(0);
  const [apiData, setApiData] = useState<ApiData[]>([]);
  const [todos, setTodos] = useState<Todo[]>([]);

  async function fetchTestAPI() {
    try {
      const baseUrl: string = "https://localhost:7148"
      const endpoint: string = "/weatherforecast";
      const url: string = `${baseUrl}${endpoint}`;
      const response = await fetch(url);
      const data = await response.json();
      // console.log(data);
      setApiData(data);
    } catch (err) {
      console.log(err);
    }
  }

  async function fetchApi(url: string) {
    try {
      const response = await fetch(url);
      const data = await response.json();
      setTodos(data);
    } catch (err) {
      console.log(err);
    }
  }

  useEffect(() => {
    fetchTestAPI();
    fetchApi("https://localhost:7148/api/todos");
  }, []); // 空の依存配列を渡して、一度だけ実行されるようにする

  return (
    <>      
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
      </div>

      {todos.length > 0 && (
        <div className="todo-data">
          <h2>Todo</h2>
          {todos.map((todo, index) => (
            <div key={index}>
              <p>Date: {todo.duedate}</p>
              <p>title: {todo.title}</p>
              <p>description: {todo.description}</p>
              {/* <p>IsCompleted: {todo.IsCompleted}</p> */}
            </div>
          ))}
        </div>
      )}
      
      {apiData.length > 0 && (
        <div className="weather-data">
          <h2>Weather Forecast</h2>
          {apiData.map((weather, index) => (
            <div key={index}>
              <p>Date: {weather.date}</p>
              <p>TemperatureC: {weather.temperatureC}°C</p>
              <p>TemperatureF: {weather.temperatureF}°F</p>
              <p>Summary: {weather.summary}</p>
            </div>
          ))}
        </div>
      )}
    </>
  )
}

export default App
