import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

interface ApiData {
  date: string,
  temperatureC: string,
  temperatureF: number,
  summary: string
}

function App() {
  const [count, setCount] = useState(0);
  const [apiData, setApiData] = useState<ApiData[]>([]);

  async function fetchTestAPI() {
    try {
      const baseUrl: string = "https://localhost:7148"
      const endpoint: string = "/weatherforecast";
      const url: string = `${baseUrl}${endpoint}`;
      const response = await fetch(url);
      const data = await response.json(response);
      // console.log(data);
      setApiData(data);
    } catch (err) {
      console.log(err);
    }
  }

  useEffect(() => {
    fetchTestAPI();
  }, []); // 空の依存配列を渡して、一度だけ実行されるようにする

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
      </div>
      
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
