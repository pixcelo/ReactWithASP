import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

async function fetchTestAPI() {
  try {
    const baseUrl: string = "https://localhost:7148"
    const endpoint: string = "/weatherforecast";
    const url: string = `${baseUrl}${endpoint}`;
    const response = await fetch(url);
    const data = await response.json(response);
    console.log(data);
  } catch (err) {
    console.log(err);
  }
}

function App() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    fetchTestAPI();
  });

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
