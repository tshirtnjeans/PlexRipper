<template>
	<v-dialog :value="show" max-width="500" @click:outside="close">
		<v-card>
			<v-card-title class="headline i18n-formatting">{{ $t(getHelpText.title) }}</v-card-title>

			<v-card-text class="i18n-formatting">{{ $t(getHelpText.text) }} </v-card-text>

			<!--	Close action	-->
			<v-card-actions>
				<v-spacer></v-spacer>
				<v-btn color="green darken-1" text @click="close"> {{ $t('general.commands.close') }} </v-btn>
			</v-card-actions>
		</v-card>
	</v-dialog>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import IText from '@interfaces/IText';

@Component
export default class HelpDialog extends Vue {
	@Prop({ required: true, type: Boolean })
	readonly show!: boolean;

	@Prop({ required: true, type: String })
	readonly id!: string;

	helpText: IText[] = [];

	close(): void {
		this.$emit('close');
	}

	get getHelpText(): IText {
		if (this.id === '') {
			return {
				id: 'help.default',
				title: 'help.default.title',
				text: 'help.default.text',
			};
		}

		return {
			id: this.id,
			title: `${this.id}.title`,
			text: `${this.id}.text`,
		};
	}
}
</script>
