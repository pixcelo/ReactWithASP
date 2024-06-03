import { useEffect, useState } from 'react'
import TodoList from './components/TodoList';
import WeatherForecast from './components/WeatherForecast';
import { WeatherForecastData, Todo } from './types';
import fetchData from './utils/fetchData';
import Button from './components/Button';
import './App.css'

function App() {  
  const [weatherForecastData, setApiData] = useState<WeatherForecastData[]>([]);
  const [todos, setTodos] = useState<Todo[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  // ボタン
  const handleClick = () => {
    console.log('ボタンがクリックされました！');
  };

  useEffect(() => {
    const fetchWeatherForecast = async() => {
      const data = await fetchData<WeatherForecastData[]>("https://localhost:7148/weatherforecast");
      setApiData(data);
    }

    const fetchTodos = async () => {
      const data = await fetchData<Todo[]>('https://localhost:7148/api/todos');
      setTodos(data);
      setIsLoading(false);
    };

    fetchWeatherForecast();
    fetchTodos();
  }, []); // 空の依存配列を渡して、一度だけ実行されるようにする

  return (
    <>
      <Button onClick={handleClick}>クリックしてください</Button>
      <TodoList todos={todos} isLoading={isLoading} />
      <WeatherForecast data={weatherForecastData} isLoading={isLoading} />
    </>
  )
}

export default App
