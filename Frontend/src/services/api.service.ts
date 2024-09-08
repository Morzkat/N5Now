import axios, { AxiosInstance } from "axios";

// Configuración de la instancia de Axios
const apiService: AxiosInstance = axios.create({
  baseURL: "https://localhost:7060/api",
  timeout: 5000,
});

export default apiService;