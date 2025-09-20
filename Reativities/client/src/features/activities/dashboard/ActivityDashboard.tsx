import { Grid } from '@mui/material';
import React from 'react';
import ActivityList from './ActivityList';

export default function ActivityDashboard() {



  return (
    <Grid container spacing={3}>
      <Grid size={7}>
        <ActivityList />
      </Grid>
      <Grid size={5}>
        Activity filter goes here
      </Grid>
    </Grid>
  )
}
