import * as React from 'react';
import { Employee } from '../models/employee';
import { Permission } from '../models/permission';
import { PermissionDto } from '../dtos/PermissionDto';
import { useState, useEffect, FormEvent } from 'react';
import { PermissionType } from '../models/permissionType';
import { getAllEmployees } from '../services/employeesService';
import { createPermission, updatePermission } from '../services/permissionService';
import { getAllPermissionTypes } from '../services/permissionTypesService';
import { Box, Button, FormControl, Grid, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from '@mui/material';


export default function PermissionForm({ permission }: { permission?: Permission }) {
    const [employee, setEmployee] = useState(permission?.employee?.id || 0);
    const [permissionType, setPermissionType] = useState(permission?.permissionType?.id || 0);
    const [date, setDate] = useState<Date>(permission?.date || new Date());
    const [permissionTypes, setPermissionTypes] = useState(Array<PermissionType>);
    const [employees, setEmployees] = useState(Array<Employee>);
    const [isNewPermission, setIsNewPermission] = useState(true);

    const fetchEmployees = async () => {
        try {
            const response = await getAllEmployees();
            setEmployees(response);
        } catch (error) {
            console.error(error);
        }
    }

    const fetchPermissionTypes = async () => {
        try {
            const response = await getAllPermissionTypes();
            setPermissionTypes(response);
        } catch (error) {
            console.error(error);
        }
    }

    useEffect(() => {
        fetchEmployees();
        fetchPermissionTypes();

        if (employee) setIsNewPermission(false);

    }, []);

    const handleEmployeeChange = (event: SelectChangeEvent) => {
        setEmployee(parseInt(event.target.value));
    };

    const handlePermissionTypeChange = (event: SelectChangeEvent) => {
        setPermissionType(parseInt(event.target.value));
    };

    const handleDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDate(new Date(event.target.value));
    };

    const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const payload: PermissionDto = {
            employee: employee,
            permissionType: permissionType,
            date: new Date(),
        };

        if (isNewPermission) {
            const response = await createPermission(payload);
            console.log('event: ', response);
        }
        else {
            payload.id = permission?.id;
            const response = await updatePermission(payload);
            console.log('event: ', response);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <Box sx={{ mx: 'auto', width: 400 }}>

                <FormControl fullWidth>
                    <InputLabel id="employee-label">Employee</InputLabel>
                    <Select
                        labelId="employee-label"
                        id="employee-select"
                        value={employee.toString()}
                        label="Employee"
                        onChange={handleEmployeeChange}
                    >
                        {
                            employees.map(x =>
                                <MenuItem key={x?.id} value={x?.id?.toString()}>
                                    {`${x.name} ${x.lastName}`}
                                </MenuItem>
                            )
                        }
                    </Select>
                </FormControl>

                <FormControl fullWidth>
                    <InputLabel id="permission-type-label">Permission Type</InputLabel>
                    <Select
                        labelId="permission-type-label"
                        id="permission-type-select"
                        value={permissionType.toString()}
                        label="Permission Type"
                        onChange={handlePermissionTypeChange}
                    >
                        {
                            permissionTypes.map(x =>
                                <MenuItem key={x?.id} value={x?.id?.toString()}>
                                    {x.description}
                                </MenuItem>
                            )
                        }
                    </Select>
                </FormControl>

                <TextField
                    label="Date"
                    type="date"
                    value={new Date(date).toISOString().slice(0, 10) ?? new Date().toISOString().slice(0, 10)}
                    onChange={handleDateChange}
                    fullWidth
                    margin="normal"
                />

                <Button type="submit" variant="contained" color="primary">
                    {isNewPermission ? 'Create Permission' : 'Update Permission'}
                </Button>

            </Box>
        </form>
    );
}
