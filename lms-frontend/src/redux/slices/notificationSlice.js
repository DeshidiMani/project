import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import notificationService from '../../services/notificationService';

export const fetchNotifications = createAsyncThunk('notifications/fetch', async (userId, thunkAPI) => {
  try {
    const response = await notificationService.fetchNotifications(userId);
    return response.data.data;
  } catch (err) {
    return thunkAPI.rejectWithValue(err.response.data.message);
  }
});

const notificationSlice = createSlice({
  name: 'notifications',
  initialState: { notifications: [], error: null },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchNotifications.fulfilled, (state, action) => {
        state.notifications = action.payload;
      })
      .addCase(fetchNotifications.rejected, (state, action) => {
        state.error = action.payload;
      });
  }
});

export default notificationSlice.reducer;
