import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Permission } from '../models/permission';
import { useEffect, useState } from 'react';
import { deletePermission, getAllPermissions } from '../services/permissionService';
import BorderColorIcon from '@mui/icons-material/BorderColor';
import N5NowModal from '../components/N5NowModal';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button, Grid } from '@mui/material';
import { deleteEmployee } from '../services/employeesService';
import PermissionForm from '../components/PermissionForm';
import { formattedDate } from '../utils/date/dateUtils';

export default function PermissionPage() {

  const [permissions, setPermissions] = useState<Permission[]>([]);

  async function fetchPermissions() {
    try {
      const response = await getAllPermissions();
      setPermissions(response);
    } catch (error) {
      console.error(error);
    }
  }

  async function handleDeletePermission(permissionId: number | undefined) {
    try {
      const response = await deletePermission(permissionId);
    } catch (error) {
      console.error(error);
    }
  }

  useEffect(() => {
    fetchPermissions();
  }, []);

  return (
    <>
      <N5NowModal openModalTag={<p>Add Permission</p>} content={<PermissionForm />} />
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 1050 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="right">Id</TableCell>
              <TableCell align="right">Name</TableCell>
              <TableCell align="right">Last Name</TableCell>
              <TableCell align="right">Permission Type</TableCell>
              <TableCell align="right">Date</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {permissions.map((permission) => (
              <TableRow
                key={permission.id}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell align="right" component="th" scope="row"> {permission.id} </TableCell>
                <TableCell align="right">{permission.employee.name}</TableCell>
                <TableCell align="right">{permission.employee.lastName}</TableCell>
                <TableCell align="right">{permission.permissionType.description}</TableCell>
                <TableCell align="right">{formattedDate(permission.date)}</TableCell>
                <TableCell align="right" >
                  <Grid item xs={8}>
                    <N5NowModal openModalTag={<BorderColorIcon />} content={<PermissionForm permission={permission} />} />
                    <Button onClick={async () => await handleDeletePermission(permission.id)}><DeleteIcon /></Button>
                  </Grid>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>

  );
}