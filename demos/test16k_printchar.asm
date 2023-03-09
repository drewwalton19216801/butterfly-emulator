    .org $bfff

main:
    lda #$42
    sta $8100
    lda #$41
    sta $8100
    lda #$44
    sta $8100
    lda #$46
    sta $8100
    lda #$4F
    sta $8100
    lda #$4F
    sta $8100
    lda #$44
    sta $8100
    brk

    .org $fffc
    .word main
    .word $0000