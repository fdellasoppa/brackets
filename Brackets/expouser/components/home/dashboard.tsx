import { StyleSheet, Text, View } from 'react-native';
import { Button } from 'react-native-paper';

import type { NativeStackScreenProps } from '@react-navigation/native-stack';

type RootStackParamList = {
  Home: undefined;
};

type HomeNavProps = NativeStackScreenProps<RootStackParamList, 'Home'>;

function HomeDashboard({ navigation }: HomeNavProps) {
  return (
    <View style={style.container}>
      <Text>Home Screen</Text>
      <Button mode="contained" onPress={() => navigation.navigate('Home')}>
        Go to details
      </Button>
    </View>
  );
}

const style = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
});