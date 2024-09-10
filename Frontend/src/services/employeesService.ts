import apiService from "./api.service";
import { Employee } from "../models/employee";

const endpoint = '/employees';

export const getAllEmployees = async (): Promise<Employee[]> => {
    try {
        const response = await apiService.get(`${endpoint}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const createEmployee = async (employee: Employee): Promise<Employee> => {
    try {
        const response = await apiService.post(`${endpoint}`, employee);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const updateEmployee = async (employee: Employee): Promise<Employee> => {
    try {
        const response = await apiService.put(`${endpoint}`, employee);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const deleteEmployee = async (employeeId: number | undefined): Promise<boolean> => {
    try {
        const response = await apiService.delete(`${endpoint}`, { data: { id: employeeId } });
        if (response.status !== 200) return false;

        return true;
    } catch (error) {
        throw error;
    }
}

