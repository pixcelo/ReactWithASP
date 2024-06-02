import React from 'react';
import { WeatherForecastData } from '../types';

interface WeatherForecastProps {
  data: WeatherForecastData[];
  isLoading: boolean;
}

const WeatherForecast: React.FC<WeatherForecastProps> = ({ data, isLoading }) => {
  return (
    <div>
      <h2>Weather Forecast</h2>
      {isLoading ? (
        <p>Loading...</p>
      ) : (
        <ul>
          {data.map((item, index) => (
            <li key={index}>
              <p>Date: {item.date}</p>
              <p>Temperature (C): {item.temperatureC}</p>
              <p>Temperature (F): {item.temperatureF}</p>
              <p>Summary: {item.summary}</p>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default WeatherForecast;