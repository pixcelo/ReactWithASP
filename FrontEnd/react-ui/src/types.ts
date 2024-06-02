
export interface WeatherForecastData {
  date: string,
  temperatureC: string,
  temperatureF: number,
  summary: string
}

export interface Todo {
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