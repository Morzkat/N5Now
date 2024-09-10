import { PermissionType } from "../models/permissionType";
import apiService from "./api.service";

const endpoint = '/permissionTypes';

export const getAllPermissionTypes = async (): Promise<PermissionType[]> => {
    try {
        const response = await apiService.get(`${endpoint}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};