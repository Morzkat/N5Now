import { PermissionDto } from "../dtos/PermissionDto";
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

export const createPermission = async (permission: PermissionDto): Promise<Permission> => {
    try {
        const response = await apiService.post(`${endpoint}`, permission);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const updatePermission = async (permission: PermissionDto): Promise<Permission> => {
    try {
        const response = await apiService.put(`${endpoint}`, permission);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const deletePermission = async (permissionId: number | undefined): Promise<boolean> => {
    try {
        const response = await apiService.delete(`${endpoint}`, {data: { id: permissionId }});
        if (response.status !== 200) return false;

        return true;
    } catch (error) {
        throw error;
    }
}

