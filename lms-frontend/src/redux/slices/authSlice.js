import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import authService from '../../services/authService';

export const login = createAsyncThunk('auth/login', async (formData, thunkAPI) => {
    try { 
        const response = await authService.login(formData);
        return response.data; // Return user and token
    } catch (err) {
        return thunkAPI.rejectWithValue(err.response.data.message);
    }
});
export const register = createAsyncThunk('auth/register', async (formData, thunkAPI) => {
  try {
    const response = await authService.register(formData);
    return response.data.message; // Only return a success message
  } catch (err) {
    return thunkAPI.rejectWithValue(err.response.data.message);
  }
});

const authSlice = createSlice({
  name: 'auth',
  initialState: {
    user: null,
    token: null,
    error: null
  },
  reducers: {
    logout: (state) => {
      state.user = null;
      state.token = null;
    }
  },
  extraReducers: (builder) => {
    builder
      .addCase(login.fulfilled, (state, action) => {
        state.user = action.payload.user; // Plain JSON object for user
        state.token = action.payload.token; // String for token
        state.error = null;
      })
      .addCase(login.rejected, (state, action) => {
        state.error = action.payload;
      })
      .addCase(register.fulfilled, (state) => {
        state.error = null; // Success
      })
      .addCase(register.rejected, (state, action) => {
        state.error = action.payload; // Store error message
      });
  }
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
