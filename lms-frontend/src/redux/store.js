import { configureStore } from '@reduxjs/toolkit';
import { combineReducers } from 'redux';
import { persistReducer, persistStore } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import authReducer from './slices/authSlice';
import courseReducer from './slices/courseSlice';
import videoReducer from './slices/videoSlice';
import enrollmentReducer from './slices/enrollmentSlice';
import assignmentReducer from './slices/assignmentSlice';
import notificationReducer from './slices/notificationSlice';
import progressReducer from './slices/progressSlice';

const persistConfig = {
  key: 'root',
  storage
};

const rootReducer = combineReducers({
  auth: authReducer,
  courses: courseReducer,
  videos: videoReducer,
  enrollment: enrollmentReducer,
  assignments: assignmentReducer,
  notifications: notificationReducer,
  progress: progressReducer
});

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) => 
    getDefaultMiddleware({
      serializableCheck: false // Temporarily disable serializable check
    }),
});

export const persistor = persistStore(store);
