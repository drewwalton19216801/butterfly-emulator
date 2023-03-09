    .org $bfff

main:
    lda #$42
    jsr printchar
    lda #$41
    jsr printchar
    lda #$44
    jsr printchar
    lda #$46
    jsr printchar
    lda #$4F
    jsr printchar
    lda #$4F
    jsr printchar
    lda #$44
    jsr printchar
    brk

printchar:
    tax
    stx $8100
    rts

    .org $fffc
    .word main
    .word $0000