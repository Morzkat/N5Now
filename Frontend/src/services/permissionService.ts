import { Permission } from "../models/permission";
import apiService from "./api.service";

const endpoint = '/permissions';

export const getAllPermissions = async (): Promise<Permission[]> => {
    try {
        const response = await apiService.get(`${endpoint}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const createPermission = async (permission: Permission): Promise<Permission> => {
    try {
        const response = await apiService.post(`${endpoint}`, permission);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const updatePermission = async (permission: Permission): Promise<Permission> => {
    try {
        const response = await apiService.put(`${endpoint}/${permission.id}`, permission);
        return response.data;
    } catch (error) {
        throw error;
    }
};


